@echo off
curl -X POST "http://127.0.0.1:47002/api/denizen/generate" ^
     -H "Content-Type: application/json" ^
     -d "{\"quantity\":300,\"startyear\":1980,\"endyear\":1990}"
