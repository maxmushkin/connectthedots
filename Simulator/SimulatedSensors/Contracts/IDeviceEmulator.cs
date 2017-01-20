namespace SimulatedSensors.Contracts
{
    public interface IDeviceEmulator
    {
        bool Pause();
        bool Resume();
        void UpdateAsset(Asset asset);
        bool DeleteAsset(Asset asset);
    }
}