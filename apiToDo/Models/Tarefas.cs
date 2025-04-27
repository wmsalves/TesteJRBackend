using apiToDo.DTO;
using System;
using System.Collections.Generic;
using System.Linq;

namespace apiToDo.Models
{
    public class Tarefas
    {

        private static List<TarefaDTO> lstTarefasDB = new List<TarefaDTO>() 
        {
            new TarefaDTO {ID_TAREFA = 1, DS_TAREFA = "Fazer Compras"},
            new TarefaDTO {ID_TAREFA = 2, DS_TAREFA = "Fazer Atividade Faculdade"},
            new TarefaDTO {ID_TAREFA = 3, DS_TAREFA = "Subir Projeto de Teste no Github"}
        };
        public List<TarefaDTO> lstTarefas()
        {
            try
            {
                return lstTarefasDB;
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro ao listar tarefas: {ex.Message}", ex);
            }
        }

        public List<TarefaDTO> InserirTarefa(TarefaDTO Request)
        {
            try
            {
                if (Request == null)
                    throw new ArgumentNullException(nameof(Request), "A tarefa enviada é nula.");

                lstTarefasDB.Add(Request);
                return lstTarefasDB;
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro ao inserir tarefa: {ex.Message}", ex);
            }
        }
        public void DeletarTarefa(int ID_TAREFA)
        {
            try
            {
                List<TarefaDTO> lstResponse = lstTarefas();
                var Tarefa = lstResponse.FirstOrDefault(x => x.ID_TAREFA == ID_TAREFA);
                TarefaDTO Tarefa2 = lstResponse.Where(x=> x.ID_TAREFA == Tarefa.ID_TAREFA).FirstOrDefault();
                lstResponse.Remove(Tarefa2);
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
    }
}
