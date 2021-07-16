all: build serve
.PHONY:

serve:
	docker run -p 8000:8000 -v $(shell pwd) bash -c "pip install markdown-include==0.6.0 && mkdocs serve -a 0.0.0.0:8000"

build:
	docker run -v $(shell pwd) bash -c "pip install markdown-include==0.6.0 && mkdocs build"