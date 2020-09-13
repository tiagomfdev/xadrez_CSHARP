using Xadrez.Tabuleiro;

namespace Game.Tela
{
    class Tela
    {
        public static void ImprimirTabuleiro(Tabuleiro tabuleiro)
        {
            for(int linhas = 0; linhas < tabuleiro.Linhas; linhas++)
            {
                for (int colunas = 0; colunas < tabuleiro.Colunas; colunas++)
                {
                    string strPeca = tabuleiro.Peca(linhas, colunas) == null ? "- " : tabuleiro.Peca(linhas, colunas).ToString();
                    System.Console.Write(strPeca);
                }
                System.Console.WriteLine();
            }
        }
    }
}
