namespace Be.Windows.Forms
{
    public partial class HexBox
    {
        #region Key interpreter methods

        private void ActivateEmptyKeyInterpreter()
        {
            if (_eki == null)
                _eki = new EmptyKeyInterpreter(this);

            if (_eki == _keyInterpreter)
                return;

            if (_keyInterpreter != null)
                _keyInterpreter.Deactivate();

            _keyInterpreter = _eki;
            _keyInterpreter.Activate();
        }

        private void ActivateKeyInterpreter()
        {
            if (_ki == null)
                _ki = new KeyInterpreter(this);

            if (_ki == _keyInterpreter)
                return;

            if (_keyInterpreter != null)
                _keyInterpreter.Deactivate();

            _keyInterpreter = _ki;
            _keyInterpreter.Activate();
        }

        private void ActivateStringKeyInterpreter()
        {
            if (_ski == null)
                _ski = new StringKeyInterpreter(this);

            if (_ski == _keyInterpreter)
                return;

            if (_keyInterpreter != null)
                _keyInterpreter.Deactivate();

            _keyInterpreter = _ski;
            _keyInterpreter.Activate();
        }

        #endregion
    }
}