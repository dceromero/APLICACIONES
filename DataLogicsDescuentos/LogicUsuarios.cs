﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessAplicaciones.DataAccessDescuentos;
using DataEntitysAplicaciones.DataEntitysDescuentos;

namespace DataLogicAplicaciones.DataLogicsDescuentos
{
    public class LogicUsuarios
    {
        MetodosUsuarios mtuser = null;

        public long ValidarUsuarios(USUARIOS user)
        {
            mtuser = new MetodosUsuarios();
            return mtuser.Validar(user);
        }

        public Mensajes PreRegistro(USUARIOS user)
        {
            mtuser = new MetodosUsuarios();
            return mtuser.PreRegistro(user);
        }

        public List<VIEW_Jefes> ListadoDeJefes()
        {
            mtuser = new MetodosUsuarios();
            return mtuser.ListadoDeJefes();
        }
    }
}
