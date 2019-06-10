namespace L2CC.Core.Interfaces.Entities.Scrolls
{
    /// <summary>
    /// Interface IScrollsReward represents container for experience scrolls rewarded for completion of an instance
    /// </summary>
    public interface IScrollsReward
    {
        /// <summary>
        /// Count for 1kk daily quest scrolls
        /// </summary>
        int OneMillDailyScrollsCount { get; }
        /// <summary>
        /// Count for 10kk daily quest scrolls
        /// </summary>
        int TenMillDailyScrollsCount { get; }
        /// <summary>
        /// Gets the ten kk scroll count.
        /// </summary>
        /// <value>The ten kk scroll count.</value>
        int TenKkScrollCount { get; }
        /// <summary>
        /// Gets the fifty kk scroll count.
        /// </summary>
        /// <value>The fifty kk scroll count.</value>
        int FiftyKkScrollCount { get; }
        /// <summary>
        /// Gets the hundred kk scroll count.
        /// </summary>
        /// <value>The hundred kk scroll count.</value>
        int HundredKkScrollCount { get; }
        /// <summary>
        /// Gets the total exp.
        /// </summary>
        /// <value>The total exp.</value>
        ulong TotalExp { get; }
        /// <summary>
        /// Gets the total money.
        /// </summary>
        /// <value>The total money.</value>
        ulong TotalMoney { get; }
        /// <summary>
        /// Adds the other scrolls to this scrolls container
        /// </summary>
        /// <param name="scrolls"></param>
        void AddScrolls(IScrollsReward scrolls);
    }
}
