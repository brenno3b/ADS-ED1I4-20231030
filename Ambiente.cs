using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace ADS_ED1I4_20231030
{
    internal class Ambiente
    {
        private int _id;
        private string _nome;
        private Queue<Log> _logs;

        public int Id { get { return _id; } }
        public string Nome { get { return _nome;} }
        public Queue<Log> Logs { get { return _logs; } }

        [JsonConstructor]
        public Ambiente(int id, string nome, Queue<Log> logs)
        {
            _id = id;
            _nome = nome;
            _logs = logs;
        }

        public Ambiente(int id, string nome)
        {
            _id = id;
            _nome = nome;
            _logs = new Queue<Log>();
        }

        public Ambiente(int id)
        {
            _id = id;
            _nome = "";
            _logs = new Queue<Log>();
        }

        public Ambiente()
        {
            _id = -1;
            _nome = "";
            _logs = new Queue<Log>();
        }

        public void RegistrarLog(Log log)
        {
            int index = log.Usuario.Ambientes.FindIndex(e => e.Id.Equals(_id));

            if (index == -1)
            {
                Log unauthorizedLog = new(log.Usuario, false);

                _logs.Enqueue(unauthorizedLog);
            } else
            {
                Log authorizedLog = new(log.Usuario, true);
                _logs.Enqueue(authorizedLog);
            }

            if (_logs.Count == 100) _logs.Dequeue();
        }

        public override string? ToString()
        {
            return $"Ambiente(\nId: {_id}, \nNome: {_nome}, \nLogs: [\n{string.Join(", \n", _logs)}\n  ]\n)";
        }
    }
}
