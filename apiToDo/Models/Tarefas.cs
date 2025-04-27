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
        public List<TarefaDTO> DeletarTarefa(int ID_TAREFA)
        {
            try
            {
                // busca a tarefa com o ID fornecido na list
                var tarefa = lstTarefasDB.FirstOrDefault(x => x.ID_TAREFA == ID_TAREFA);
                // verifica se a tarefa foi encontrada
                if (tarefa == null)
                {
                    // se nao encontrou, lança uma erro
                    throw new Exception($"Tarefa com ID {ID_TAREFA} não encontrada.");
                }
                // remove a tarefa encontrada da list
                lstTarefasDB.Remove(tarefa);

                // retorna a list de tarefas atualizada
                return lstTarefasDB;
            }
            catch (Exception ex)
            {
                // exception para qualquer outro erro que possa ocorrer
                throw new Exception($"Erro ao deletar tarefa: {ex.Message}", ex);
            }
        }
    }
 }

