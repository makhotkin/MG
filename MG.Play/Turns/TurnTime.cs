using System.Runtime.InteropServices;

namespace MG.Play.Turns
{
	[StructLayout(LayoutKind.Explicit)]
	public struct TurnTime
	{
		[FieldOffset(0)]
		public ushort TurnNumber;
		[FieldOffset(2)]
		public PhaseType Phase;
		[FieldOffset(3)]
		public byte ExtraPhaseNumber; // there can be extra combat phase, etc
		[FieldOffset(4)]
		public uint Tick;             // To be incremented when a player gains priority (or on state based actions?)
		[FieldOffset(0)]
		public ulong TimeStamp;

		public static implicit operator ulong(TurnTime t) {
			return t.TimeStamp;
		}

		public static implicit operator TurnTime(ulong ts) {
			return new TurnTime() { TimeStamp = ts };
		}


		public void Advance()
		{
			Tick++;
		}
	}
}