namespace Web3Unity.Scripts.Library.Ethers.RLP
{
    /// <summary>
    ///     Wrapper class for decoded elements from an RLP encoded byte array.
    /// </summary>
    public interface IRLPElement
    {
        byte[] RLPData { get; }
    }
}