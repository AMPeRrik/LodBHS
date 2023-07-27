using Stride.Engine;

namespace LOD
{
    class LODApp
    {
        static void Main(string[] args)
        {
            using (var game = new Game())
            {
                game.Run();
            }
        }
    }
}
