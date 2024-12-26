using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VdBlockchain.Classes;

namespace VdBlockchain
{
    class Program
    {
        public static List<Block> blockchain = new List<Block>();
        static void Main(string[] args)
        {
            blockchain.Add(new Block("Nguyen The Phong", "0"));
            blockchain.Add(new Block("Mat ma va do phuc tap thuat toan", blockchain.ElementAt(blockchain.Count - 1).hash));
            blockchain.Add(new Block("Khoa Toan Tin", blockchain.ElementAt(blockchain.Count - 1).hash));
            blockchain.Add(new Block("Dai hoc Bach khoa Ha Noi", blockchain.ElementAt(blockchain.Count - 1).hash));

            Console.WriteLine("Blockchain is valid: " + IsChainValid());

            string printBlockChain = new System.Web.Script.Serialization.JavaScriptSerializer().Serialize(blockchain);
            Console.WriteLine(printBlockChain);

            string data, previousHash;
            Console.WriteLine();
            Console.WriteLine("New Block");
            Console.Write("Data: ");
            data = Console.ReadLine();
            Console.Write("Previous Hash: ");
            previousHash = Console.ReadLine();
            blockchain.Add(new Block(data, previousHash));
            string printBlockChain1 = new System.Web.Script.Serialization.JavaScriptSerializer().Serialize(blockchain);
            Console.WriteLine(printBlockChain1);
            Console.WriteLine("Blockchain is valid: " + IsChainValid());
            Console.ReadLine();
        }

        public static Boolean IsChainValid()
        {
            Block currentBlock;
            Block previousBlock;

            for (int i = 1; i < blockchain.Count; i++)
            {
                currentBlock = blockchain.ElementAt(i);
                previousBlock = blockchain.ElementAt(i - 1);

                if (!currentBlock.hash.Equals(currentBlock.CalculateHash()))
                {
                    Console.WriteLine("Current Hashes not equal");
                    return false;
                }

                if (!previousBlock.hash.Equals(currentBlock.previousHash))
                {
                    Console.WriteLine("Previous Hashes not equal");
                    return false;
                }
            }
            return true;
        }
    }
}
