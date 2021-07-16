all: build serve
.PHONY:

serve:
	docker run -p 8000:8000 -v $(shell pwd):/website https://github.com/gaspare-mascolino/knowledge.git:develop bash -c "pip install markdown-include==0.6.0 && mkdocs serve -a 0.0.0.0:8000"

build:
	docker build https://github.com/gaspare-mascolino/knowledge.git
	