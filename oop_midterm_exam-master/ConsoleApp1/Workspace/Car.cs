namespace ConsoleApp1.Exam
{
    public class Car
    {
        private readonly Engine _engine;

        public bool IsEngineStarted { get; private set; } = true;

        public Car(Engine engine)
        {
            _engine = engine;
        }

        public void StartCar()
        {
            _engine.Start();
        }

    }

    // Car and Engine (Composition example)
    public class Engine
    {
        public void Start()
        {
        }
    }

}


