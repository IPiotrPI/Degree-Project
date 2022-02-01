namespace PongEx1
{
    class PongAI : Mind
    {
        //DECLARE paddle body
        public IBody _body;

        public override IBody ReturnBody()
        {
            return _body;
        }
        public override void onCollide(IBody entity)
        {

        }

        public override void update()
        {
            
        }
    }
}
