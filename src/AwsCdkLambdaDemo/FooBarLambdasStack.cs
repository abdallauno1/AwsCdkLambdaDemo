using Amazon.CDK;
using Amazon.CDK.AWS.Lambda;
using Constructs;
using Amazon.CDK.AWS.APIGateway;

namespace cdk
{
    public class FooBarLambdasStack : Stack
    {
        internal FooBarLambdasStack(Construct scope, string id, IStackProps props = null) : base(scope, id, props)
        {
            var fooLambda = new Amazon.CDK.AWS.Lambda.Function(this, "fooLambda", new FunctionProps
            {
                Runtime = Runtime.DOTNET_6,

                // relative to the cdk.json file
                Code = Code.FromAsset("src/FooLambda/bin/Debug/net6.0/publish/"),

                //Assembly::Type:Method
                Handler = "FooLambda::FooLambda.Function::Get"
            });

            new LambdaRestApi(this, "fooApiEndpoint", new LambdaRestApiProps()
            {

                Handler = fooLambda
            });


            var barLambda = new Amazon.CDK.AWS.Lambda.Function(this, "barLambda", new FunctionProps
            {
                Runtime = Runtime.DOTNET_6,

                // relative to the cdk.json file
                Code = Code.FromAsset("src/BarLambda/bin/Debug/net6.0/publish/"),

                //Assembly::Type:Method
                Handler = "BarLambda::BarLambda.Function::Get"
            });


            new LambdaRestApi(this, "barApiEndpoint", new LambdaRestApiProps()
            {

                Handler = barLambda
            });

        }
    }
}
