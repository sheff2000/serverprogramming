from django.db import models

# Create your models here.
class User(models.Model):
    name = models.CharField(max_length=100)
    email = models.EmailField()
    dateCreate = models.DateTimeField(auto_now_add=True)