.PHONY: all build test docker-build start-dev-env stop-dev-env start-prod-env stop-prod-env clean rebuild-images test login-ghcr push-all

# Environment variables from .env.prod
include .env.prod
export $(shell sed 's/=.*//' .env.prod)

# Define variables
DOCKER_REGISTRY=ghcr.io/leeberte
APP_NAME=web3lapp
TAG=latest

# Define paths to each service's Dockerfile directory
MARKETING_DIR=../../Client/Marketing/web3laliberte.heroview
ADMIN_DIR=../../Client/Office/web3laliberte.adminportal
OPERATIONS_DIR=../../Server/Services/Web3Laliberte.OperationsAPI

#===============================================================================#
# Development Environment
#===============================================================================#

# Start all services in the development environment
start-dev-env:
	docker-compose -f docker-compose.dev.yml up -d 

# Stop all services in the development environment
stop-dev-env:
	docker-compose -f docker-compose.dev.yml down

# Rebuild and restart the web3lapp-admin service
rebuild-web3lapp-admin:
	docker-compose -f docker-compose.dev.yml build web3lapp-admin && \
	docker-compose -f docker-compose.dev.yml up -d web3lapp-admin

# Rebuild and restart the web3lapp-marketing service
rebuild-web3lapp-marketing:
	docker-compose -f docker-compose.dev.yml build web3lapp-marketing && \
	docker-compose -f docker-compose.dev.yml up -d web3lapp-marketing

# Rebuild and restart the web3lapp-operations service
rebuild-web3lapp-operations:
	docker-compose -f docker-compose.dev.yml build web3lapp-operations && \
	docker-compose -f docker-compose.dev.yml up -d web3lapp-operations

# Rebuild all images in parallel
rebuild-images:
	$(MAKE) rebuild-web3lapp-admin &
	$(MAKE) rebuild-web3lapp-marketing &
	$(MAKE) rebuild-web3lapp-operations &
	wait

# Test all services in parallel
test:
	$(MAKE) -C $(OPERATIONS_DIR) test &
	wait

# Clean up Docker images and containers for microservices
clean:
	$(MAKE) -C $(OPERATIONS_DIR) clean &
	wait

#===============================================================================#
# Production Environment
#===============================================================================#

# Start all services in the production environment
start-prod-env:
	docker-compose -f docker-compose.prod.yml up -d 

# Stop all services in the production environment
stop-prod-env:
	docker-compose -f docker-compose.prod.yml down

# Login to GitHub Container Registry
login-ghcr:
	@echo "Logging into GitHub Container Registry..."
	@echo $(GITHUB_PAT) | docker login ghcr.io -u $(GITHUB_USERNAME) --password-stdin

# Build Docker images
build-marketing:
	@echo "Building marketing image..."
	docker build -t $(DOCKER_REGISTRY)/$(APP_NAME)-marketing-app:$(TAG) $(MARKETING_DIR)

build-admin:
	@echo "Building admin image..."
	docker build -t $(DOCKER_REGISTRY)/$(APP_NAME)-admin-app:$(TAG) $(ADMIN_DIR)

build-operations:
	@echo "Building operations image..."
	docker build -t $(DOCKER_REGISTRY)/$(APP_NAME)-operations-api:$(TAG) $(OPERATIONS_DIR)

# Push Docker images to GitHub Container Registry
push-marketing: build-marketing
	@echo "Pushing marketing image..."
	docker push $(DOCKER_REGISTRY)/$(APP_NAME)-marketing-app:$(TAG)

push-admin: build-admin
	@echo "Pushing admin image..."
	docker push $(DOCKER_REGISTRY)/$(APP_NAME)-admin-app:$(TAG)

push-operations: build-operations
	@echo "Pushing operations image..."
	docker push $(DOCKER_REGISTRY)/$(APP_NAME)-operations-api:$(TAG)

# Combine all build and push steps for production
push-all: push-marketing push-admin push-operations
	@echo "All images built and pushed successfully!"