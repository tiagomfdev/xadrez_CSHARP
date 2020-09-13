using System;

namespace Xadrez.Tabuleiro.Exceptions
{
    class TabuleiroException : SystemException
    {
        public TabuleiroException(string msg) : base(msg) 
        { 
        }
    }
}
