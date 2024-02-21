using System;

namespace Cryptography.En_Decryption {
    public class InverseKeysGenerator {
        private readonly int _symbolsAmount;
        
        public InverseKeysGenerator(int symbolsAmount) {
            _symbolsAmount = symbolsAmount;
        }
        
        public int GenerateInverseKey(int key) {
            int t = 0;
            int newt = 1;
            int r = _symbolsAmount;
            int newr = key;

            while (newr != 0)
            {
                int quotient = r / newr;
                
                int temp = t;
                t = newt;
                newt = temp - quotient * newt;
                
                temp = r;
                r = newr;
                newr = temp - quotient * newr;
            }

            if (r > 1)
                throw new Exception("Не обратимо");

            if (t < 0)
                t += _symbolsAmount;

            return t;    
        }
    }
}