using System.ComponentModel;

public class ProductDto
{
    public string? Id { get; set; }  // Tương ứng với "$oid" trong JSON

    public int Position { get; set; } // Thêm trường Position

    public string? Name { get; set; }

    public string? ImageCover { get; set; }

    public string? CategoryId { get; set; } // Giữ nguyên CategoryId cho ID của category

    public string? CategoryName { set; get; }

    public string? SupplierId { get; set; } // Thêm SupplierId

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

    public DisplayTechnologyDto? DisplayTechnology { get; set; } // Giữ nguyên DisplayTechnology nếu có dữ liệu
}
public class VideoRecordingDto
{
    public string? Resolution { get; set; }

    public string? FrameRate { get; set; }

    public string? RecordingMode { get; set; }

    public string? OtherFeatures { get; set; } // Thêm trường OtherFeatures
}
public class ConnectivityDto
{
    public string? MobileNetwork { get; set; }

    public string? SIM { get; set; } // Thêm trường SIM

    public string? Wifi { get; set; }

    public string? GPS { get; set; } // Thêm trường GPS

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

    public string? GPU { get; set; } // Thêm trường GPU nếu có dữ liệu
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

    public string? Secondary { get; set; } // Thêm trường Secondary nếu có dữ liệu
}
public class DisplayTechnologyDto
{
    public string? ScreenType { get; set; } // Thêm trường ScreenType nếu có dữ liệu

    public string? Features { get; set; }

    public string? MaxBrightness { get; set; } // Thêm trường MaxBrightness nếu có dữ liệu
}
public class VariantDto
{
    public string? Id { get; set; }  // Tương ứng với "$oid" trong JSON

    public string? Color { get; set; }

    public string? ColorCode { get; set; }

    public List<string>? Images { get; set; }

    public List<MemoryOptionDto>? MemoryOptions { get; set; }
}
public class MemoryOptionDto
{
    public string? Id { get; set; }  // Tương ứng với "$oid" trong JSON

    public string? Storage { get; set; }

    public double Price { get; set; }

    public double OldPrice { get; set; }

    public int Quantity { get; set; } // Thêm trường Quantity nếu có dữ liệu
}
