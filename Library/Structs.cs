using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Library
{
    public enum TCStatus
    {
        aberto = 0,
        notificando = 1,
        assinado = 2,
        descomprido = 3
    }

    public enum TCNotificacao
    {
        nenhuma = 0,
        notificacao1 = 1,
        notificacao2 = 2,
        notificacao3 = 3
    }
}
