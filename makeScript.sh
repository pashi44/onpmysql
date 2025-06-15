#!/bin/bash

# Script: run_migrations.sh
# Usage: ./run_migrations.sh [DbContextName] [MigrationName]

# Check if dotnet is available
if ! command -v dotnet &> /dev/null
then
    echo "Error: dotnet command not found"
    exit 1
fi

# Get command line arguments
DBCONTEXT=${1:-"IdenDbContext"}  # Default to CsvDbContext if not specified
MIGRATION_NAME=${2:-"InitialMigration"}  # Default migration name

# Step 1: Build the project
echo "Building project..."
if dotnet build; then
    echo "Build succeeded!"

    echo "removinf Migrations"
if dotnet-ef migrations remove --context $DBCONTEXT;  then
    echo "'$MIGRATION_NAME' removed\n"


   # Step 2: Create migration
    echo "Creating migration '$MIGRATION_NAME' for context '$DBCONTEXT'..."
    if dotnet-ef migrations add "$MIGRATION_NAME" --context "$DBCONTEXT"; then
        echo "Migration created successfully!"
        
        # Step 3: Apply migration
       # echo "Applying migrations..."
       # if dotnet ef database update --context "$DBCONTEXT"; then
       #     echo "Migrations applied successfully!"
            
            # Step 4: Run the application
            echo "Starting application..."
            dotnet   watch 
        else
            echo "Error applying migrations!"
            exit 1
        fi
    else
        echo "Error creating migration!"
        exit 1
    fi
else
    echo "Build failed!"
    exit 1
fi
