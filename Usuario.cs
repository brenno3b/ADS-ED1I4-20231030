using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Reflection.Metadata.BlobBuilder;

namespace ADS_ED1I4_20231030
{
    internal class Usuario
    {
        private int _id;
        private string _nome;
        private List<Ambiente> _ambientes;

        public int Id { get { return _id; } }
        public string Nome { get { return _nome; } }
        public List<Ambiente> Ambientes { get { return _ambientes; } }

        [JsonConstructor]
        public Usuario(int id, string nome, List<Ambiente> ambientes)
        {
            _id = id;
            _nome = nome;
            _ambientes = ambientes;
        }

        public Usuario(int id, string nome)
        {
            _id = id;
            _nome = nome;
            _ambientes = new List<Ambiente>();
        }

        public Usuario(int id)
        {
            _id = id;
            _nome = "";
            _ambientes = new List<Ambiente>();
        }

        public Usuario()
        {
            _id = -1;
            _nome = "";
            _ambientes = new List<Ambiente>();
        }

        public bool ConcederPermissão(Ambiente ambiente)
        {
            int index = _ambientes.FindIndex(e => ambiente.Id.Equals(e.Id));

            if (index > -1) return false;

            _ambientes.Add(ambiente);

            return true;
        }

        public bool RevogarPermissão(Ambiente ambiente)
        {
            int index = _ambientes.FindIndex(e => ambiente.Id.Equals(e.Id));

            if (index == -1) return false;

            _ambientes.RemoveAt(index);

            return true;
        }

        public override string? ToString()
        {
            return $"Usuario(\nId: {_id}, \nNome: {_nome}, \nAmbientes: [\n{string.Join(", ", _ambientes)}  ]\n)";
        }
    }
}
