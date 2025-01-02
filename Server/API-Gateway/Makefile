.PHONY: all build test docker-build start stop clean

# Default task - Build and test services, then start all services
all: build test docker-build start


rebuild-web3lapp-admin:
	docker-compose -f docker-compose.dev.yml build web3lapp-admin && docker-compose -f docker-compose.dev.yml up -d web3lapp-admin

rebuild-web3lapp-operations:
	docker-compose -f docker-compose.dev.yml build web3lapp-operations && docker-compose -f docker-compose.dev.yml up -d web3lapp-operations


rebuild-react-images:
	make rebuild-web3lapp-admin &
	make rebuild-web3lapp-operations 


# Build all services in parallel
build:
	$(MAKE) -C ../Services/Web3Laliberte.OperationsAPI build & 

	wait

# Test all services in parallel
test:
	$(MAKE) -C ../Services/Web3Laliberte.OperationsAPI test &
	wait


# Start all services
start:
	docker-compose -f docker-compose.dev.yml up -d 

# Stop Kong and all services
stop:
	docker-compose.dev.yml down


# Clean up Docker images and containers for microservices
clean:
	$(MAKE) -C ../Services/Web3Laliberte.OperationsAPI clean &