namespace VamosAJogo.Core.Model
{
    public enum CallStatus
    {
        Unanswered = -1,
        NotGoing = 0,
        Going = 1,
        MaybeGoing = 2,
    }
    public class SportEventCall : BaseEntity
    {
        protected SportEventCall(Player player, CallStatus status)
        {
            Player = player;
            Status = status;
        }

        public CallStatus Status { get; protected set; }

        public Player Player { get; protected set; }

        internal static SportEventCall CreateCall(Player player, CallStatus status)
        {
            return new SportEventCall(player, status);
        }
    }
}
