using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.Collections.Generic;
using System.ComponentModel;

public class Product
{
    [BsonId]
    public ObjectId Id { get; set; }

    [BsonElement("name")]
    public string? Name { get; set; }

    [BsonElement("image_cover")]
    public string? ImageCover { get; set; }

    [BsonElement("category_id")]
    public ObjectId CategoryId { get; set; }

    [BsonElement("supplier_id")]
    public ObjectId SupplierId { get; set; }

    [BsonElement("describe")]
    public List<string>? Describe { get; set; }

    [BsonElement("product_details")]
    public ProductDetails? ProductDetails { get; set; }

    [BsonElement("variants")]
    public List<Variant>? Variants { get; set; }
}

public class ProductDetails
{

    [BsonElement("video_recording")]
    public VideoRecording? VideoRecording { get; set; }

    [BsonElement("colors")]
    public List<string>? Colors { get; set; }

    [BsonElement("storage_options")]
    public List<string>? StorageOptions { get; set; }

    [BsonElement("connectivity")]
    public Connectivity? Connectivity { get; set; }

    [BsonElement("dimensions")]
    public Dimensions? Dimensions { get; set; }

    [BsonElement("screen_resolution")]
    public string? ScreenResolution { get; set; }

    [BsonElement("waterproof_dustproof")]
    public string? WaterproofDustproof { get; set; }

    [BsonElement("chip")]
    public Chip? Chip { get; set; }

    [BsonElement("battery")]
    public Battery? Battery { get; set; }

    [BsonElement("rear_camera")]
    public Camera? RearCamera { get; set; }

    [BsonElement("security")]
    public string? Security { get; set; }

    [BsonElement("front_camera")]
    public string? FrontCamera { get; set; }

    [BsonElement("display_technology")]
    public DisplayTechnology? DisplayTechnology { get; set; }
}

public class VideoRecording
{
    [BsonElement("resolution")]
    public string? Resolution { get; set; }

    [BsonElement("frame_rate")]
    public string? FrameRate { get; set; }

    [BsonElement("recording_mode")]
    public string? RecordingMode { get; set; }

    [BsonElement("other_features")]
    public string? OtherFeatures { get; set; }
}

public class Connectivity
{
    [BsonElement("mobile_network")]
    public string? MobileNetwork { get; set; }

    [BsonElement("sim")]
    public string? SIM { get; set; }

    [BsonElement("wifi")]
    public string? Wifi { get; set; }

    [BsonElement("gps")]
    public string? GPS { get; set; }

    [BsonElement("bluetooth")]
    public string? Bluetooth { get; set; }

    [BsonElement("charging_port")]
    public string? ChargingPort { get; set; }

    [BsonElement("headphone_jack")]
    public string? HeadphoneJack { get; set; }
}

public class Dimensions
{
    [BsonElement("length")]
    public string? Length { get; set; }

    [BsonElement("width")]
    public string? Width { get; set; }

    [BsonElement("thickness")]
    public string? Thickness { get; set; }

    [BsonElement("weight")]
    public string? Weight { get; set; }
}

public class Chip
{
    [BsonElement("cpu")]
    public string? CPU { get; set; }

    [BsonElement("cpu_speed")]
    public string? CPUSpeed { get; set; }

    [BsonElement("gpu")]
    public string? GPU { get; set; }
}

public class Battery
{
    [BsonElement("capacity")]
    public string? Capacity { get; set; }

    [BsonElement("type")]
    public string? Type { get; set; }

    [BsonElement("charging")]
    public string? Charging { get; set; }

    [BsonElement("charger_included")]
    public string? ChargerIncluded { get; set; }

    [BsonElement("battery_technology")]
    public string? BatteryTechnology { get; set; }
}

public class Camera
{
    [BsonElement("primary")]
    public string? Primary { get; set; }

    [BsonElement("secondary")]
    public string? Secondary { get; set; }
}

public class DisplayTechnology
{
    [BsonElement("screen_type")]
    public string? ScreenType { get; set; }

    [BsonElement("features")]
    public string? Features { get; set; }

    [BsonElement("max_brightness")]
    public string? MaxBrightness { get; set; }
}

public class Variant
{
    [BsonId]
    [BsonElement("id")]
    public ObjectId Id { get; set; }

    [BsonElement("color")]
    public string? Color { get; set; }

    [BsonElement("color_code")]
    public string? ColorCode { get; set; }

    [BsonElement("images")]
    public List<string>? Images { get; set; }

    [BsonElement("memory_options")]
    public List<MemoryOption>? MemoryOptions { get; set; }
}

public class MemoryOption
{
    [BsonId]
    [BsonElement("id")]
    public ObjectId Id { get; set; }
    [BsonElement("storage")]
    public string? Storage { get; set; }

    [BsonElement("price")]
    public double Price { get; set; }

    [BsonElement("old_price")]
    public double OldPrice { get; set; }

    [BsonElement("quantity")]
    public int Quantity { get; set; }
}
