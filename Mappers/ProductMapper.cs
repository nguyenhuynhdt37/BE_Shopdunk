using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BE_Shopdunk.Dtos.ProductDto;
using BE_Shopdunk.Model;
using MongoDB.Bson;
using MongoDB.Driver;

namespace BE_Shopdunk.Mappers
{
    public static class ProductMapper
    {
        public static ProductDto ToProductDto(this Product product)
        {
            var productDto = new ProductDto
            {
                Id = product.Id.ToString(),
                Name = product.Name,
                CategoryId = product.CategoryId.ToString(),
                ImageCover = product.ImageCover,
                Describe = product.Describe,
                ProductDetails = new ProductDetailsDto
                {
                    VideoRecording = new VideoRecordingDto
                    {
                        Resolution = product.ProductDetails?.VideoRecording?.Resolution,
                        FrameRate = product.ProductDetails?.VideoRecording?.FrameRate,
                        RecordingMode = product.ProductDetails?.VideoRecording?.RecordingMode
                    },
                    Colors = product.ProductDetails?.Colors,
                    StorageOptions = product.ProductDetails?.StorageOptions,
                    Connectivity = new ConnectivityDto
                    {
                        MobileNetwork = product.ProductDetails?.Connectivity?.MobileNetwork,
                        Wifi = product.ProductDetails?.Connectivity?.Wifi,
                        Bluetooth = product.ProductDetails?.Connectivity?.Bluetooth,
                        ChargingPort = product.ProductDetails?.Connectivity?.ChargingPort,
                        HeadphoneJack = product.ProductDetails?.Connectivity?.HeadphoneJack
                    },
                    Dimensions = new DimensionsDto
                    {
                        Length = product.ProductDetails?.Dimensions?.Length,
                        Width = product.ProductDetails?.Dimensions?.Width,
                        Thickness = product.ProductDetails?.Dimensions?.Thickness,
                        Weight = product.ProductDetails?.Dimensions?.Weight
                    },
                    ScreenResolution = product.ProductDetails?.ScreenResolution,
                    WaterproofDustproof = product.ProductDetails?.WaterproofDustproof,
                    Chip = new ChipDto
                    {
                        CPU = product.ProductDetails?.Chip?.CPU,
                        CPUSpeed = product.ProductDetails?.Chip?.CPUSpeed
                    },
                    Battery = new BatteryDto
                    {
                        Capacity = product.ProductDetails?.Battery?.Capacity,
                        Type = product.ProductDetails?.Battery?.Type,
                        Charging = product.ProductDetails?.Battery?.Charging
                    },
                    RearCamera = new CameraDto
                    {
                        Primary = product.ProductDetails?.RearCamera?.Primary
                    },
                    Security = product.ProductDetails?.Security,
                    FrontCamera = product.ProductDetails?.FrontCamera,
                    DisplayTechnology = new DisplayTechnologyDto
                    {
                        ScreenType = product.ProductDetails?.DisplayTechnology?.ScreenType,
                        Features = product.ProductDetails?.DisplayTechnology?.Features
                    }
                },
                Variants = product?.Variants?.Select(v => new VariantDto
                {
                    Id = v.Id.ToString(),
                    Color = v.Color,
                    ColorCode = v.ColorCode,
                    Images = v.Images,
                    MemoryOptions = v.MemoryOptions.Select(mo => new MemoryOptionDto
                    {
                        Storage = mo.Storage,
                        Price = mo.Price,
                        OldPrice = mo.OldPrice
                    }).ToList()
                }).ToList()
            };

            return productDto;
        }
        public static ProductBannerDto toProductBannerDto(this Product product)
        {
            return new ProductBannerDto
            {
                Id = product.Id.ToString(),

                Name = product.Name,

                ImageCover = product.ImageCover,

                Price = (double)(product?.Variants?[0].MemoryOptions[0].Price),

                OldPrice = (double)(product?.Variants?[0].MemoryOptions?[0].OldPrice)
            };
        }
    }
}