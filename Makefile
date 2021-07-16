all: build serve
.PHONY:

serve:
	docker login nexus3.nex.intranet.unicreditgroup.eu:9080/v2/documentation/python-mkdocs/manifests/0.0.2 --username '<guest>' --password '<nexus>'
	docker run -p 8000:8000 -v $(shell pwd):/website nexus3.nex.intranet.unicreditgroup.eu:9080/documentation/python-mkdocs:0.0.2 bash -c "pip install markdown-include==0.6.0 && mkdocs serve -a 0.0.0.0:8000"

build:
	docker run -v $(shell pwd):/website nexus3.nex.intranet.unicreditgroup.eu:9080/documentation/python-mkdocs:0.0.2 bash -c "pip install markdown-include==0.6.0 && mkdocs build"