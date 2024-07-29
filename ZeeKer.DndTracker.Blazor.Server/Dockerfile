FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
RUN apt-get update
RUN apt-get install -y libc6 libicu-dev libfontconfig1
WORKDIR /app
#EXPOSE 80
#EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build

WORKDIR /src
RUN  dotnet nuget add source https://nuget.devexpress.com/rwKmNdqY94SpyRsYPPVUAvHgyP4Zfz4Ile3pNBzse3BwdqU1WF/api/v3/index.json -n devexpress-nuget
COPY ["ZeeKer.DndTracker.Blazor.Server/ZeeKer.DndTracker.Blazor.Server.csproj", "ZeeKer.DndTracker.Blazor.Server/"]
COPY ["ZeeKer.DndTracker.Module/ZeeKer.DndTracker.Module.csproj", "ZeeKer.DndTracker.Module/"]
COPY ["ZeeKer.DndTracker.LongStoryShort/ZeeKer.DndTracker.LongStoryShort.csproj", "ZeeKer.DndTracker.LongStoryShort/"]
RUN dotnet restore "./ZeeKer.DndTracker.Blazor.Server/ZeeKer.DndTracker.Blazor.Server.csproj"
COPY . .
WORKDIR "/src/ZeeKer.DndTracker.Blazor.Server"
RUN dotnet build "./ZeeKer.DndTracker.Blazor.Server.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "./ZeeKer.DndTracker.Blazor.Server.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ZeeKer.DndTracker.Blazor.Server.dll"]