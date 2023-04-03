using System;
using NUnit.Framework;
using Web3Unity.Scripts.Library.Ethers.Providers;
using Web3Unity.Scripts.Library.Ethers.Transactions;
using Formatter = Web3Unity.Scripts.Library.Ethers.Transactions.Formatter;
using Nethereum.Hex.HexConvertors.Extensions;
using System.Data.Common;
using Web3Unity.Scripts.Library.Ethers.RLP;
using System.Linq;

namespace Tests
{
    [TestFixture]
    public class TransactionTests
    {
        private JsonRpcProvider _ganacheProvider;

        [Test]
        public void EncodeElement_String_ReturnsByteArray()
        {
            string txJson = "{\"to\":\"0x6Eb893e3466931517a04a17D153a6330c3f2f1dD\",\"nonce\":648,\"gasLimit\":\"0x9d\",\"gasPrice\":\"0x237e\",\"maxFeePerGas\":\"0x346d9246\",\"maxPriorityFeePerGas\":\"0x2c7e63\",\"data\":\"0x889e365e59664fb881554ba1175519b5195b1d20390beb806d8f2cda7893e6f79848195dba4c905db6d7257ffb5eefea35f18ae33c\",\"value\":\"0xc854\",\"accessList\":[],\"chainId\":\"0x8404bf1f\",\"type\":0}";
            // Convert JSON object to bytes
            byte[] txBytes = System.Text.Encoding.UTF8.GetBytes(txJson);
            string txHex = BitConverter.ToString(txBytes).Replace("-", "");
            // Parse transaction bytes
            Transaction tx = new Formatter().Parse(txHex);
            Console.WriteLine(tx);
        }

    }
}