# SurveySystem  

Запуск:  
1. выполнить `docker compose up`
2. применить миграции к бд, после запуска контейнеров:  
   `dotnet ef --project DAL database update  --context SurveySystemContext --startup-project WebApi` 
