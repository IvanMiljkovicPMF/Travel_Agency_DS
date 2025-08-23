using System;

namespace Models.AllPackages
{
    public abstract class PackageFactory
    {
        public abstract TravelPackage CreatePackage();
    }

    public class CruisePackageFactory : PackageFactory
    {
        public override TravelPackage CreatePackage() => new CruisePackage();
    }

    public class SeaPackageFactory : PackageFactory
    {
        public override TravelPackage CreatePackage() => new SeaPackage();
    }

    public class MountainPackageFactory : PackageFactory
    {
        public override TravelPackage CreatePackage() => new MountainPackage();
    }

    public class ExcursionPackageFactory : PackageFactory
    {
        public override TravelPackage CreatePackage() => new ExcursionPackage();
    }

    public static class FactoryPackage
    {
        public static TravelPackage Create(PackageType packageType)
        {
            PackageFactory factory = packageType switch
            {
                PackageType.Cruise => new CruisePackageFactory(),
                PackageType.Sea => new SeaPackageFactory(),
                PackageType.Mountain => new MountainPackageFactory(),
                PackageType.Excursion => new ExcursionPackageFactory(),
                _ => throw new ArgumentException("Unknown package type")
            };

            return factory.CreatePackage();
        }
    }
}
