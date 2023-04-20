using ChainSafe.GamingWeb3.EVM.Transactions;
using Newtonsoft.Json;

namespace ChainSafe.GamingWeb3.EVM.Blocks
{
    /// <summary>
    /// Block including transaction objects
    /// </summary>
    public class BlockWithTransactions : Block
    {
        /// <summary>
        /// Array - Array of transaction objects
        /// </summary>
        [JsonProperty(PropertyName = "transactions")]
        public TransactionResponse[] Transactions { get; set; }
    }
}