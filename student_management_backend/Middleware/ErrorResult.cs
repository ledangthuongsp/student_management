﻿namespace student_management_backend.Middleware;
public class ErrorResult
{
    public List<string>? Messages { get; set; }

    public string? Source { get; set; }
    public string? ErrorId { get; set; }
    public int StatusCode { get; set; }
}