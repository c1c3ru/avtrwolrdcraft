using System.Collections.Generic;

namespace AvatarWorld.Core.Avatar
{
    /// <summary>
    /// Historico do editor de avatar (botoes desfazer/refazer da cena AvatarMaker): guarda copias da aparencia.
    /// Escolher algo depois de desfazer descarta o que podia ser refeito.
    /// </summary>
    public sealed class AvatarEditHistory
    {
        readonly List<AvatarAppearance> _states = new List<AvatarAppearance>();
        int _index;

        public AvatarEditHistory(AvatarAppearance initial)
        {
            _states.Add(initial.Clone());
        }

        public AvatarAppearance Initial => _states[0].Clone();
        public AvatarAppearance Current => _states[_index].Clone();
        public bool CanUndo => _index > 0;
        public bool CanRedo => _index < _states.Count - 1;
        public bool HasChanges => _index > 0;

        /// <summary>Registra uma nova aparencia; ignora se for igual a atual.</summary>
        public void Push(AvatarAppearance appearance)
        {
            if (appearance.SameAs(_states[_index])) return;
            _states.RemoveRange(_index + 1, _states.Count - _index - 1);
            _states.Add(appearance.Clone());
            _index++;
        }

        public AvatarAppearance Undo() { if (CanUndo) _index--; return Current; }
        public AvatarAppearance Redo() { if (CanRedo) _index++; return Current; }
    }
}
