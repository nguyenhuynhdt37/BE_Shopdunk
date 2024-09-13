using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.Collections.Generic;
using System.ComponentModel;

public class ProductDto
{
    public string? Id { get; set; }

    public string? Name { get; set; }

    public string? ImageCover { get; set; }

    public string? CategoryName { get; set; }

    public string? CategoryId { get; set; }

    public List<string>? Describe { get; set; }

    public ProductDetailsDto? ProductDetails { get; set; }

    public List<VariantDto>? Variants { get; set; }
}

public class ProductDetailsDto
{
    public VideoRecordingDto? VideoRecording { get; set; }

    public List<string>? Colors { get; set; }

    public List<string>? StorageOptions { get; set; }

    public ConnectivityDto? Connectivity { get; set; }

    public DimensionsDto? Dimensions { get; set; }

    [DisplayName("Screen resolution")]
    public string? ScreenResolution { get; set; }

    public string? WaterproofDustproof { get; set; }

    public ChipDto? Chip { get; set; }

    public BatteryDto? Battery { get; set; }

    public CameraDto? RearCamera { get; set; }

    public string? Security { get; set; }

    public string? FrontCamera { get; set; }

    public DisplayTechnologyDto? DisplayTechnology { get; set; }
}

public class VideoRecordingDto
{
    public string? Resolution { get; set; }

    public string? FrameRate { get; set; }

    public string? RecordingMode { get; set; }
}

public class ConnectivityDto
{
    public string? MobileNetwork { get; set; }

    public string? Wifi { get; set; }

    public string? Bluetooth { get; set; }

    public string? ChargingPort { get; set; }

    public string? HeadphoneJack { get; set; }
}

public class DimensionsDto
{
    public string? Length { get; set; }

    public string? Width { get; set; }

    public string? Thickness { get; set; }

    public string? Weight { get; set; }
}

public class ChipDto
{
    public string? CPU { get; set; }

    public string? CPUSpeed { get; set; }
}

public class BatteryDto
{
    public string? Capacity { get; set; }

    public string? Type { get; set; }

    public string? Charging { get; set; }
}

public class CameraDto
{
    public string? Primary { get; set; }
}

public class DisplayTechnologyDto
{
    public string? ScreenType { get; set; }

    public string? Features { get; set; }
}

public class VariantDto
{
    public string? Id { get; set; }

    public string? Color { get; set; }

    public string? ColorCode { get; set; }

    public List<string>? Images { get; set; }

    public List<MemoryOptionDto>? MemoryOptions { get; set; }
}

public class MemoryOptionDto
{
    public string? Id { get; set; }
    
    public string? Storage { get; set; }

    public double Price { get; set; }

    public double OldPrice { get; set; }
}
