using System.Collections.Generic;
using System.Linq;

namespace Cryptography {
	public enum InputMask : int {
		Tb1     = 1 << 0,
		Tb2     = 1 << 1,
		Tb3     = 1 << 2,
		Tb4     = 1 << 3,
		Dvg     = 1 << 4,
		LbSize  = 1 << 5,
		NudSize = 1 << 6,
	}

	public static class InputMaskExtensions {
		public static InputMask CreateMask(this IEnumerable<InputMask> flags) {
			return (InputMask) flags.Aggregate(0, (current, flag) => current | (int)flag);
		}
	}
}