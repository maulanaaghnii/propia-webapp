FROM python:3.11-slim

WORKDIR /app

COPY services/extra/denizen-generator-scheduler/requirements.txt .
RUN pip install --no-cache-dir -r requirements.txt

COPY services/extra/denizen-generator-scheduler/ .

EXPOSE 80

CMD ["python", "main.py"]
