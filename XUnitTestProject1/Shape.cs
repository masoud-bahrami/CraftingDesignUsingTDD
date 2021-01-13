namespace XUnitTestProject1
{

    public interface IPluggable
    {
        void MouseMove();
        void MouseUp();
    }

    public class SingleMode: IPluggable
    {
        public void MouseMove()
        {
            throw new System.NotImplementedException();
        }

        public void MouseUp()
        {
            throw new System.NotImplementedException();
        }
    }

    public class MultiShapeSelectionMode : IPluggable
    {
        public void MouseMove()
        {
            throw new System.NotImplementedException();
        }

        public void MouseUp()
        {
            throw new System.NotImplementedException();
        }
    }
    public class Editor
    {
        private IPluggable _pluggable;

        
        public void MouseDown()
        {

            if (Select() != null)
                _pluggable = new SingleMode();
            else
                _pluggable = new MultiShapeSelectionMode();
        }



        public void MouseMove()
        {
            _pluggable.MouseMove();
        }
        

        public void MouseUp()
        {
            _pluggable.MouseUp();
        }

        private void MoveTheShape(Shape shap)
        {
            
        }

        private void MoveSelectionRectangle()
        {

        }

        private Shape Select()
        {
            return new Shape();
        }


        private void SelectShape(Shape shape)
        {

        }
    }

    internal class Shape
    {
    }
}