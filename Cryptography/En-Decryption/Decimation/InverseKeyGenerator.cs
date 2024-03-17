using System;

namespace Cryptography.En_Decryption.Decimation {
    public class InverseKeysGenerator {
        private readonly int _symbolsAmount;
        
        public InverseKeysGenerator(int symbolsAmount) {
            _symbolsAmount = symbolsAmount;
        }
        
        /// <exception cref="ArgumentException">Thrown when the key is not reversible (when the key and the symbols amount are not mutually prime).</exception>
        public int GenerateInverseKey(int key, int modulus) {
            key = (key % modulus + modulus) % modulus; // Приводим число к положительному представлению

            int m0 = modulus;
            int x0 = 0;
            int x1 = 1;

            if (modulus == 1)
                return 0;

            while (key > 1)
            {
                int q = key / modulus;

                int temp = modulus;
                modulus = key % modulus;
                key = temp;

                temp = x0;
                x0 = x1 - q * x0;
                x1 = temp;
            }

            if (x1 < 0)
                x1 += m0;

            return x1;   
        }
    }
}