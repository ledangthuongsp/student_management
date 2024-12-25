using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using student_management_backend.Models;

public class EUserRoleConverter : JsonConverter<EUserRole>
{
    public override EUserRole Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        var value = reader.GetString();
        return value switch
        {
            "Student" => EUserRole.Student,
            "Teacher" => EUserRole.Teacher,
            "Council" => EUserRole.Council,
            _ => throw new ArgumentException("Invalid enum value."),
        };
    }

    public override void Write(Utf8JsonWriter writer, EUserRole value, JsonSerializerOptions options)
    {
        writer.WriteStringValue(value.ToString());
    }
}