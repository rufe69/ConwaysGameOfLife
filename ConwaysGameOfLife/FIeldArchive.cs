using System;
using System.Collections.Generic;
using System.Text;

namespace ConwaysGameOfLife
{
    /// <summary> Класс, отвечающий за хранения состояний объекта</summary>
    class FieldArchive
    {
        /// <summary> Список снимков состояний field</summary>
        private List<FieldSnapshot> snapshots;

        /// <summary> Конструктор</summary>
        public FieldArchive()
        {
            snapshots = new List<FieldSnapshot>();
        }

        /// <summary> Добавляет новый снимок состояния объекта field</summary>
        /// <param name="field"> Объект, состояние которого необходимо сохранить</param>
        public void Add(Field field) => snapshots.Add(new FieldSnapshot(field));

        /// <summary> Смотрит, содержится ли состояние объекта field в списке состояний</summary>
        /// <param name="field"> Объект <c>Field</c>, с которым сравниваются состояния из списка</param>
        public bool Contains(Field field)
        {
            foreach (var snapshot in snapshots)
                if (snapshot.Compare(field))
                    return true;
            return false;
        }
    }
}
