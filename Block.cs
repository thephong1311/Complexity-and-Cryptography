using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VdBlockchain.Classes;

namespace VdBlockchain
{
    class Block
    {
        public String hash;
        public String previousHash;
        private String data;

        private long timeStamp;
        private int nonce = 0;

        public Block(String data, String previousHash)
        {
            this.data = data;
            this.previousHash = previousHash;
            this.timeStamp = DateTimeHandle.GetTime();
            this.hash = CalculateHash();
        }

        public String CalculateHash()
        {
            Sha256 sha256 = new Sha256();
            String calculatedhash = sha256.Hash(previousHash + timeStamp.ToString() + nonce.ToString() + data);
            return calculatedhash;
        }
    }
}
