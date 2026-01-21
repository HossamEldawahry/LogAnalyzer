# LogAnalyzer
# Overview
# 
# This project analyzes large server log files (10GB+) to identify the top 5 most frequent IP addresses using a memory-efficient and multi-threaded approach.
# 
# /************************************************************************************************************************/
# 
# Approach
# 
# Streaming file reading to avoid loading large files into memory.
# 
# Parallel processing using Parallel.ForEach.
# 
# Thread-safe counting via ConcurrentDictionary.
# 
# /************************************************************************************************************************/
# 
# Data Structures & Threading
# Component					**			Reason
# ConcurrentDictionary		**			Lock-free, high concurrency
# StreamReader + yield		**			Minimal memory footprint
# Parallel.ForEach			**			CPU efficient
# 
# /************************************************************************************************************************/
# 
# Trade-offs
# 
# ✔ Pros
# 
# Scales to very large files
# 
# High CPU utilization
# 
# Clean, testable architecture
# 
# ❌ Cons
# 
# Ordering requires snapshot copy
# 
# Slight overhead from thread coordination
# 
# /************************************************************************************************************************/
# 
# Alternatives Considered
# 1️- Dictionary + lock
# 
# ❌ Rejected
# 
# High contention
# 
# Poor scalability
# 
# 2️- Load file into memory
# 
# ❌ Rejected
# 
# Impossible with 10GB+
# 
# 3️- LINQ only solution
# 
# ❌ Rejected
# 
# High memory pressure
# 
# Less control over performance
# 
# 4️- Channels / Pipelines
# 
# ❌ Rejected (overkill)
# 
# Adds complexity without clear benefit here
# 
# /************************************************************************************************************************/
# 
# Conclusion
# 
# This solution balances performance, memory efficiency, and code quality, making it suitable for production-scale log analysis.