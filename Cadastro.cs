using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADS_ED1I4_20231030
{
    internal class Cadastro
    {
        private List<Usuario> _usuarios;
        private List<Ambiente> _ambientes;

        public List<Usuario> Usuarios { get { return _usuarios; } }
        public List<Ambiente> Ambientes { get { return _ambientes; } }

        public Cadastro()
        {
            _usuarios = new List<Usuario>();
            _ambientes = new List<Ambiente>();
        }

        public void AdicionarUsuario(Usuario usuario)
        {
            _usuarios.Add(usuario);
        }

        public bool RemoverUsuario(Usuario usuario)
        {
            int index = _usuarios.FindIndex(e => usuario.Id.Equals(e.Id));

            if (index == -1) return false;

            if (_usuarios.ElementAt(index).Ambientes.Count > 0) return false;

            _usuarios.RemoveAt(index);

            return true;
        }

        public Usuario PesquisarUsuario(Usuario usuario)
        {
            int index = _usuarios.FindIndex(e => usuario.Id.Equals(e.Id));

            if (index == -1) return new();

            return _usuarios.ElementAt(index);
        }

        public void AdicionarAmbiente(Ambiente ambiente)
        {
            _ambientes.Add(ambiente);
        }

        public bool RemoverAmbiente(Ambiente ambiente)
        {
            int index = _ambientes.FindIndex(e => ambiente.Id.Equals(e.Id));

            if (index == -1) return false;

            _ambientes.RemoveAt(index);

            return true;
        }

        public Ambiente PesquisarAmbiente(Ambiente ambiente)
        {
            int index = _ambientes.FindIndex(e => ambiente.Id.Equals(e.Id));

            if (index == -1) return new();

            return _ambientes.ElementAt(index);
        }

        public void Upload()
        {
            if (_ambientes.Count > 0)
            {
                string json = JsonConvert.SerializeObject(_ambientes);
                File.WriteAllText("ambientes.json", json);
            }

            if (_usuarios.Count > 0)
            {
                string json = JsonConvert.SerializeObject(_usuarios);
                File.WriteAllText("usuarios.json", json);
            }
        }

        public void Download()
        {
            if (File.Exists("ambientes.json"))
            {
                string json = File.ReadAllText("ambientes.json");
                _ambientes = JsonConvert.DeserializeObject<List<Ambiente>>(json);
            }

            if (File.Exists("usuarios.json"))
            {
                string json = File.ReadAllText("usuarios.json");
                _usuarios = JsonConvert.DeserializeObject<List<Usuario>>(json);
            }
        }
    }
}
