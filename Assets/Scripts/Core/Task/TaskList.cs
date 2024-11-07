using System.Collections;
using System.Collections.Generic;

namespace Core.Task
{
    public class TaskList : IEnumerable
    {
        private readonly List<IEnumerator> _tasks = new();
        private int _index = 0;

        private int Count => _tasks.Count;
        public object Current => _index < Count ? _tasks[_index].Current : null;

        public void Add(params IEnumerator[] tasks)
        {
            _tasks.AddRange(tasks);
        }

        public bool MoveNext()
        {
            if (_index < Count)
            {
                var isDone = !_tasks[_index].MoveNext();
                if (!isDone)
                {
                    if (Current == null)
                    {
                        _index++;
                    }
                    else if (Current is IEnumerator)
                    {
                        _tasks.Add((IEnumerator) Current);
                        _index++;
                    }
                }
                else
                {
                    _tasks.RemoveAt(_index);
                }

                return false;
            }

            _index = 0;
            return true;
        }

        public void Reset() { }

        public IEnumerator GetEnumerator()
        {
            throw new System.NotImplementedException();
        }
    }
}