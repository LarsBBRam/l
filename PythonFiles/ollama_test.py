import asyncio
import ollama


async def prompt(prmt: str) -> str:
    client = ollama.AsyncClient(host = 'http://localhost:11434')
    response = await client.generate(
        model = 'deepseek-r1:1.5b',
        prompt = prmt
    )
    return response['response']