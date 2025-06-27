import chromadb


def create_and_fetch_from_chromadb(text: str):
    client = chromadb.Client()
    documents = [
        "Testdocument containing information about the import of fruit into the norwegian market!",
        "Testdocument containing information about creating LLMs and working with vectorisation across a set of documents",
        "I like turtles",
        "Na na na na na na na na na na na na, Batman! Batman..."
    ]
    collection = client.create_collection(name = "test_collection")
    for index, document in enumerate(documents):
        collection.add(
            ids = [str(index)],
            documents = document
        )
    query_result = collection.query(
        query_texts = [text],
        n_results = 2
    )
    print(query_result)