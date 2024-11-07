using System.Collections;
using UnityEngine;

namespace Core.Task
{
    public class TaskExecutor : MonoBehaviour
    {
        private TaskList _taskList;
        public static System.Func<IEnumerator, YieldInstruction> RunCoroutine;

        private void Awake()
        {
            RunCoroutine = StartCoroutine;
        }

        public void Execute(TaskList taskList)
        {
            _taskList = taskList;
        }

        private void Process(TaskList taskList)
        {
            while (!taskList.MoveNext())
            {
                // TODO
            }
        }

        private void Update()
        {
            if (_taskList != null)
            {
                Process(_taskList);
            }
        }
    }
}