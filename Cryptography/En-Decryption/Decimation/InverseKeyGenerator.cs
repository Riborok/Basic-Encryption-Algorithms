using System;

namespace Cryptography.En_Decryption.Decimation {
    public class InverseKeysGenerator {
        private readonly int _symbolsAmount;
        
        public InverseKeysGenerator(int symbolsAmount) {
            _symbolsAmount = symbolsAmount;
        }
        
        /// <exception cref="ArgumentException">Thrown when the key is not reversible (when the key and the symbols amount are not mutually prime).</exception>
        public int GenerateInverseKey(int key) {
            int t = 0;
            int newT = 1;
            int r = _symbolsAmount;
            int newR = key;

            while (newR != 0)
            {
                int quotient = r / newR;
                
                int temp = t;
                t = newT;
                newT = temp - quotient * newT;
                
                temp = r;
                r = newR;
                newR = temp - quotient * newR;
            }

            if (r > 1)
                throw new ArgumentException($"{nameof(InverseKeysGenerator)}: The key '{key}' isn't reversible!");

            if (t < 0)
                t += _symbolsAmount;

            return t;    
        }
    }
}