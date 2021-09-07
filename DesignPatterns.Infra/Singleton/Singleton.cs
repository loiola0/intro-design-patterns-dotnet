using System;

namespace DesignPatterns.Infra.Singleton
{
    public sealed class Singleton
    {
        public Guid Id {get;} = Guid.NewGuid();
        
    }
}