using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace ADS_ED1I4_20231030
{
    internal class Log
    {
        private DateTime _dtAcesso;
        private Usuario _usuario;
        private bool _tipoAcesso;

        public DateTime DtAcesso { get { return _dtAcesso;} }
        public Usuario Usuario { get {  return _usuario; } }
        public bool TipoAcesso { get { return _tipoAcesso;}}

        [JsonConstructor]
        public Log(DateTime dtAcesso, Usuario usuario, bool tipoAcesso)
        {
            _dtAcesso = dtAcesso;
            _usuario = usuario;
            _tipoAcesso = tipoAcesso;
        }

        public Log(Usuario usuario, bool tipoAcesso)
        {
            _dtAcesso = DateTime.Now;
            _usuario = usuario;
            _tipoAcesso = tipoAcesso;
        }

        public Log(Usuario usuario)
        {
            _dtAcesso = DateTime.Now;
            _usuario = usuario;
            _tipoAcesso = false;
        }

        public override string? ToString()
        {
            return $"Log(DtAcesso: {_dtAcesso},Usuario: {_usuario.Nome},TipoAcesso: {_tipoAcesso})";
        }
    }
}
