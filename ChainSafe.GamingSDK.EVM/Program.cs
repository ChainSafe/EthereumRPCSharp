using System;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using NBitcoin;
using NBitcoin.Crypto;
using Nethereum.Hex.HexConvertors.Extensions;
using Nethereum.Hex.HexTypes;
using Nethereum.Signer;
using Nethereum.Util;
using Nethereum.Web3.Accounts;
using Newtonsoft.Json;
using Org.BouncyCastle.Math;
using Web3Unity.Scripts.Library.Ethers.Contracts;
using Web3Unity.Scripts.Library.Ethers.HDNode;
using Web3Unity.Scripts.Library.Ethers.Network;
using Web3Unity.Scripts.Library.Ethers.Providers;
using Web3Unity.Scripts.Library.Ethers.Signers;
using Web3Unity.Scripts.Library.Ethers.Transactions;
using Transaction = Web3Unity.Scripts.Library.Ethers.Transactions.Transaction;


namespace EthersCSharpv2
{
    public class Program : BaseSigner
    {
        private readonly Key _signingKey;
        public static async Task Main(string[] args)
        {
            await GetRPCData();
            await GetNetwork();
            CreateEthWallet();
        }
        
        public BaseProvider BaseProvider { get; }

        private static async Task GetRPCData()
        {
            ServicePointManager.Expect100Continue = true;
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
            var account = new Account("ADD_KEY", 5);

            //var provider = new JsonRpcProvider(account,"https://staging-v3.skalenodes.com/v1/staging-faint-slimy-achird");
            var provider = new JsonRpcProvider(account,"https://goerli.infura.io/v3/2ea27900c8784457ac03b1cbd4e7b8f0");
            var accountBalance = await provider.GetBalance("0xd25b827D92b0fd656A1c829933e9b0b836d5C3e2");
            var blockNumber = await provider.GetBlockNumber();
            var getBlock = await provider.GetBlock();
           
            Console.WriteLine("Account Balance: " + accountBalance);
            Console.WriteLine("Block Number: " + blockNumber);
            Console.WriteLine("Block Info: " + JsonConvert.SerializeObject(getBlock, Formatting.Indented));

            var signer = new JsonRpcSigner(provider,account);
            var providerSigner = provider.GetSigner(account);
            Console.WriteLine("Provider Signer: " + providerSigner.GetAddress().Result);
            var transaction = new TransactionRequest
            {
                To = signer.GetAddress().Result,
                GasPrice = 100000.ToHexBigInteger(),
                GasLimit = 100000.ToHexBigInteger(),
                Value = new HexBigInteger(100000)
            };
            var result = await signer.SignTransaction(
                "ADD_KEY",
                "0xd25b827D92b0fd656A1c829933e9b0b836d5C3e2", 123);
            Console.WriteLine("Result: " + result);
        }

        public static async Task<string> GetNetwork()
        {
            var provider = new JsonRpcProvider("https://staging-v3.skalenodes.com/v1/staging-faint-slimy-achird");
            var network = await provider.GetNetwork();
            Console.WriteLine($"Network name: {network.Name}");
            Console.WriteLine($"Network chain id: {network.ChainId}");

            return network.Name;
        }

        public static void CreateEthWallet()
        {
            // Generate a random seed using the RNGCryptoServiceProvider
            byte[] randomBytes = new byte[16];
            using (RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider())
            {
                rng.GetBytes(randomBytes);
            }
            // Convert the random bytes to a mnemonic seed phrase
            string seedPhrase = new Mnemonic(Wordlist.English, randomBytes).ToString();

            Console.WriteLine("Seed phrase: " + seedPhrase);

            // Convert the seed phrase to a 64-byte seed using PBKDF2
            byte[] salt = Encoding.UTF8.GetBytes("mnemonic");
            using (var pbkdf2 = new Rfc2898DeriveBytes(seedPhrase, salt, 2048))
            {
                byte[] seed = pbkdf2.GetBytes(32);

                // Keep generating a private key until a valid one is obtained
                EthECKey privateKey;
                do
                {
                    privateKey = new EthECKey(seed, true);
                    seed = Increment(seed);
                } while (!IsValidPrivateKey(privateKey.GetPrivateKeyAsBytes()));

                // Print the private key
                Console.WriteLine("Private key: " + privateKey.GetPrivateKeyAsBytes().ToHex());

                // Generate the Ethereum public address from the private key
                string address = privateKey.GetPublicAddress().ToLower();
                
            
                // Print the Ethereum public address
                Console.WriteLine("Public address: " + address);
            }
        }
        
        public override Task<string> SignMessage(byte[] message)
        {
            var hash = new Sha3Keccack().CalculateHash(message);
            return Task.FromResult(_signingKey.Sign(new uint256(hash)).ToCompact().ToHex());
        }

        public override Task<string> SignMessage(string message)
        {
            var hash = new Sha3Keccack().CalculateHash(message);
            return Task.FromResult(_signingKey.Sign(new uint256(hash)).ToCompact().ToHex());
        }
        
        static bool IsValidPrivateKey(byte[] privateKeyBytes)
        {
            // Convert the private key bytes to a BigInteger
            BigInteger privateKey = new BigInteger(1, privateKeyBytes);

            // Check if the private key is within the range of valid private keys for the secp256k1 curve
            BigInteger n = new BigInteger("FFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFEBAAEDCE6AF48A03BBFD25E8CD0364141", 16);
            return privateKey.CompareTo(BigInteger.One) >= 0 && privateKey.CompareTo(n) < 0;
        }

        static byte[] Increment(byte[] bytes)
        {
            // Increment the least significant byte by 1
            byte[] result = new byte[bytes.Length];
            Array.Copy(bytes, result, bytes.Length);
            for (int i = result.Length - 1; i >= 0; i--)
            {
                if (result[i] < 255)
                {
                    result[i]++;
                    break;
                }
                else
                {
                    result[i] = 0;
                }
            }

            return result;
        }

        public Program(IProvider provider) : base(provider)
        {
        }
    }
}