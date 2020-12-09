namespace PatternsChudakovGA
{
    public interface ILateExecute: IController
    {
        void LateExecute(float deltaTime);
    }
}