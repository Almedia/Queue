using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Queue.Services
{
    public class SendQueue
    {
        public  void SendMessage()
        {
            var factory=new RabbitMQ.Client.ConnectionFactory(){ HostName="localhost" };
            using(var connection=factory.CreateConnection())
            {
                using(var channel=connection.CreateModel())
                {
                    channel.QueueDeclare(
                        queue:"CreateRegisteredCustomer",
                        durable:true,
                        exclusive:true,
                        autoDelete:false,
                        arguments:null
                    );
                    
                    string message="kalite";
                    var body = Encoding.UTF8.GetBytes(message);
                    
                    channel.BasicPublish(
                        exchange:"hello",
                        routingKey:"",
                        mandatory:true,
                        basicProperties:null,
                        body:body
                    );
                    
                    
                }
            }
        }
    }
}
